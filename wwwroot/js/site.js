// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//function to auto add dashes to phone input feild on registration page
function addDashes(f) {
    f_val = f.value.replace(/\D[^\.]/g, "");
    f.value = f_val.slice(0, 3) + "-" + f_val.slice(3, 6) + "-" + f_val.slice(6);
}


//for checkout
function checkout(pubKey, sessionId) {
    const stripe = Stripe(pubKey);
    stripe.redirectToCheckout({ sessionId });
}
