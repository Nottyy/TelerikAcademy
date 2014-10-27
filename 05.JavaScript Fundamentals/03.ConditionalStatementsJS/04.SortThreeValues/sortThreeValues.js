function onFindBiggerButtonClick() {
    var first = parseInt(document.getElementById('tb-first').value);
    var second = parseInt(document.getElementById('tb-second').value);
    var third = parseInt(document.getElementById('tb-third').value);
    var buffer = 0;

    for (var i = 0; i < 2; i++) {
        if (first < second) {
            buffer = second;
            second = first;
            first = buffer;
            if (first < third) {
                buffer = third;
                third = first;
                first = buffer;
            }
        }
        else {
            if (second < third) {
                buffer = third;
                third = second;
                second = buffer;
            }
        }
    }

    console.log('The descending order of the three values is: ' + first + ' ' + second + ' ' + third);
}