function onFindBiggerButtonClick() {
    var x = parseFloat(document.getElementById('tb-first').value);
    var y = parseFloat(document.getElementById('tb-second').value);
    var radius = 5;

    if (((x * x) + (y * y)) < (radius * radius)) {
        console.log('Point (' + x + ',' + y + ')' + ' is within a circle K(0,5)');
    }
    else {
        console.log('Point (' + x + ',' + y + ')' + ' is outside a circle K(0,5)');
    }

}