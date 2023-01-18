const form = document.querySelector('.rent-form');
const priceField = document.querySelector('.total-price');
const amountField = document.querySelector('.amount');

const dateToday = new Date();
const dateTomorrow = new Date(dateToday);

dateTomorrow.setDate(dateTomorrow.getDate() + 1)

form.start.value = dateToday.toISOString().slice(0, 16);
form.end.value = dateTomorrow.toISOString().slice(0, 16);

updateTotalPrice();

form.addEventListener('change', e => {
    if (e.target.tagName === 'INPUT') {
        updateTotalPrice();
    }
})


function updateTotalPrice() {

    const startDate = new Date(form.start.value);
    const endDate = new Date(form.end.value);
    const deltaDays = (endDate - startDate) / (1000 * 60 * 60 * 24);
    const totalPrice = deltaDays * amountField.textContent;

    deltaDays > 0 ? priceField.innerText = `Total price: ${totalPrice.toFixed(2)} PLN` : priceField.innerText = `Invalid end date`
}