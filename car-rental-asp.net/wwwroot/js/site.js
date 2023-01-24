const form = document.querySelector('.rent-form');
const priceField = document.querySelector('.total-price');
const amountField = document.querySelector('.amount');
const submitBtn = document.querySelector('.submit-btn');
const carId = document.querySelector('.car-id').textContent;
const apiUrl = `https://localhost:7276/api/admins/getcarrentals/${carId}`


loadReservations()
    .then(resp => initForm(resp))
    .catch(err => console.log(err));

setChangeEvent();

function loadReservations() {
    return fetch(apiUrl)
        .then(resp => { return resp.json() })
}

function initForm(reservationList) {

    const dateToday = new Date();
    const dateTomorrow = new Date(dateToday);

    dateTomorrow.setDate(dateTomorrow.getDate() + 1)

    while (!isAvailabilityCar(reservationList, Date.parse(dateToday), Date.parse(dateTomorrow))) {
        dateToday.setDate(dateToday.getDate() + 1)
        dateTomorrow.setDate(dateToday.getDate() + 1)
    }


    form.start.value = dateToday.toISOString().slice(0, 16);
    form.end.value = dateTomorrow.toISOString().slice(0, 16);

    priceField.innerText = `Total price: ${amountField.textContent} PLN`;

}

function setChangeEvent() {
    form.addEventListener('change', e => {
        if (e.target.tagName === 'INPUT') {

            const formStart = Date.parse(form.start.value);
            const formEnd = Date.parse(form.end.value);

            const qtyDays = calculateDays(formStart, formEnd);

            if (qtyDays > 0) {
                loadReservations()
                    .then(reservationList => {
                        if (isAvailabilityCar(reservationList, formStart, formEnd)) {

                            updateTotalPrice(qtyDays);
                            submitBtn.disabled = false;
                        }
                        else {
                            priceField.innerText = `The car is not available at this time`
                            submitBtn.disabled = true;
                        }
                    })
            }
            else {
                priceField.innerText = `Invalid date range`
                submitBtn.disabled = true;
            }

        }
    })
}

function isAvailabilityCar(reservationList, formStart, formEnd) {

    function checkFunc(reservation) {
        const resStart = Date.parse(reservation.startDate);
        const resEnd = Date.parse(reservation.endDate);

        return formStart > resEnd || formEnd < resStart;
    }

    return reservationList.every(checkFunc)
}

function calculateDays(formStart, formEnd) {
    return Math.ceil((formEnd - formStart) / (1000 * 60 * 60 * 24));
}

function updateTotalPrice(deltaDays) {
    const totalPrice = deltaDays * amountField.textContent;
    priceField.innerText = `Total price: ${totalPrice.toFixed(2)} PLN`;
}
