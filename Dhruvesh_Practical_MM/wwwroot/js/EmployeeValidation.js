document.addEventListener("DOMContentLoaded", function () {
    var registrationForm = document.getElementById('registrationForm');
    var NameValue = document.getElementById("txtName");
    var EmailValue = document.getElementById("txtEmail");
    var phoneValue = document.getElementById("txtPhone");
    var addressValue = document.getElementById("txtAddress");

    registrationForm.addEventListener('submit', function (event) {
        if (!validate()) {
            event.preventDefault();
        }
    });

    NameValue.addEventListener('input', function () {
        validateName();
    });

    EmailValue.addEventListener('input', function () {
        validateEmail();
    });

    phoneValue.addEventListener('input', function () {
        validatePhone();
    });

    addressValue.addEventListener('input', function () {
        validateAddress();
    });

    function validate() {
        var isValid = true;

        if (!validateName()) {
            isValid = false;
        }

        if (!validateEmail()) {
            isValid = false;
        }

        if (!validatePhone()) {
            isValid = false;
        }

        if (!validateAddress()) {
            isValid = false;
        }

        return isValid;
    }

    function validateName() {
        var name = NameValue.value;
        var regName = /^[A-Za-z\s]+$/;

        if (name == "" || !regName.test(name)) {
            document.getElementById('nameerror').innerHTML = "Please enter a valid name.";
            return false;
        } else {
            document.getElementById('nameerror').innerHTML = "";
            return true;
        }
    }

    function validateEmail() {
        var email = EmailValue.value;
        var regEmail = /^[a-zA-Z0-9._%+-]+@gmail\.com$/;

        if (email == "" || !regEmail.test(email)) {
            document.getElementById('emailerror').innerHTML = "Please enter a valid email. Must be a gmail.com";
            return false;
        } else {
            document.getElementById('emailerror').innerHTML = "";
            return true;
        }
    }

    function validatePhone() {
        var phone = phoneValue.value;
        var regPhone = /^[6-9]\d{9}$/;

        if (phone == "" || !regPhone.test(phone)) {
            document.getElementById('phoneerror').innerHTML = "Please enter a valid phone number. First letter must be 6-9.";
            return false;
        } else {
            document.getElementById('phoneerror').innerHTML = "";
            return true;
        }
    }

    function validateAddress() {
        var address = addressValue.value;

        if (address == "") {
            document.getElementById('addresserror').innerHTML = "Please enter an address.";
            return false;
        } else {
            document.getElementById('addresserror').innerHTML = "";
            return true;
        }
    }
});
