




function changeFields() {
    let checkBox = document.getElementsByName('radio')[0];
    let abilitiesDiv = document.getElementById('abilities');
    let schoolDiv = document.getElementById('school');

    if (checkBox.checked == true) {
        abilitiesDiv.style.display = 'block';
        schoolDiv.style.display = 'block'
        clearInput();
    }
    else {
        abilitiesDiv.style.display = 'none';
        schoolDiv.style.display = 'none'
        clearInput();
    }
}

function clearInput() {
    var elements = document.getElementById('registerForm').elements;

    for (let i = 2; i < elements.length; i++) {
        var elType = elements[i].type.toLowerCase();

        switch (elType) {
            case "text":
                elements[i].value = "";
                break;
            case "password":
                elements[i].value = "";
                break;
            case "email":
                elements[i].value = "";
                break;

            default:
                break;
        }
    }
}
