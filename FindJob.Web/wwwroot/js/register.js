




function changeFields() {
    let checkBox = document.getElementsByName('radio')[0];
    let abilitiesDiv = document.getElementById('abilities');
    let schoolDiv = document.getElementById('school');

    if (checkBox.checked == true) {
        abilitiesDiv.style.display = 'block';
        schoolDiv.style.display = 'block'
    }
    else {
        abilitiesDiv.style.display = 'none';
        schoolDiv.style.display = 'none'
    }
}
