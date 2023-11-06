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

function MoreChildren() {

    var childInput = document.getElementById('childInput');
    var Message = document.getElementById('Message');


    var numberValue = parseInt(childInput.value);

    // Clear existing error message
    Message.textContent = '';

    // Check if the number is greater than 1
    if (numberValue > 1) {
        // Display the error message
        Message.textContent = "Add the child First Name's in the feild below. ";
    }
}

function CheckForMoreThanOneName() {
    var textInput = document.getElementById('ChildNames');
    var childInput = document.getElementById('childInput');
    var numberValue = parseInt(childInput.value);

    if (numberValue > 1) {
        // Get the value of the text input
        var inputValue = textInput.value;

        // Replace spaces with spaces followed by an ampersand (&)
        var modifiedValue = inputValue.replace(/&/g, '  ');
        modifiedValue = inputValue.replace(/ /g, ' & ');

        textInput.value = modifiedValue;
        inputValue.trim()
    }
   
}



//print the class list
function printTable() {
    var el = document.getElementById("myTable");
    el.setAttribute('border', '1px');
    el.setAttribute('cellpadding', '5');
    newPrint = window.open("");
    newPrint.document.write(el.outerHTML);
    newPrint.print();
    newPrint.close();
}
// Close the window afer cancle print
window.addEventListener('afterprint', function () {
    window.close();
    window.location.href = 'about:blank';
});
