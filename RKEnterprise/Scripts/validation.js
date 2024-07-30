document.addEventListener('DOMContentLoaded', function () {
    var fields = ['Name', 'Email', 'PhoneNumber', 'Message', 'CV'];

    fields.forEach(function (field) {
        var inputElement = document.getElementById(field);

        inputElement.addEventListener('input', function () {
            validateField(field, inputElement.value);
        });
    });

    function validateField(field, value) {
        var validationMessageElement = document.querySelector('[data-valmsg-for="' + field + '"]');

        if (field === 'Email') {
            if (!isValidEmail(value)) {
                validationMessageElement.innerHTML = 'Please enter a valid email address.';
                return;
            }
        } else if (field === 'PhoneNumber') {
            if (!isValidPhoneNumber(value)) {
                validationMessageElement.innerHTML = 'Invalid phone number.';
                return;
            }
        }
        //else if (field === 'CV') {
        //    inputElement.addEventListener('change', function () {
        //        validateFileField(inputElement);
        //    });
        //}

        if (value.trim() !== "") {
            validationMessageElement.innerHTML = '';
        }
        //else {
        //    validationMessageElement.innerHTML = 'This field is required.';
        //}
    }

    function isValidEmail(email) {
        var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailPattern.test(email);
    }

    function isValidPhoneNumber(phoneNumber) {
        var phonePattern = /^[6-9]\d{9}$/;
        return phonePattern.test(phoneNumber);
    }

    //function validateFileField(inputElement) {
    //    var validationMessageElement = document.querySelector('[data-valmsg-for="CV"]');
    //    var file = inputElement.files[0];
    //    if (file) {
    //        var allowedExtensions = ['pdf', 'doc', 'docx'];
    //        var extension = file.name.split('.').pop().toLowerCase();
    //        if (allowedExtensions.indexOf(extension) === -1) {
    //            validationMessageElement.innerHTML = 'Only PDF, DOC, and DOCX files are allowed.';
    //        } else {
    //            validationMessageElement.innerHTML = '';
    //        }
    //    } else {
    //        validationMessageElement.innerHTML = 'Please upload your CV.';
    //    }
    //}

});
