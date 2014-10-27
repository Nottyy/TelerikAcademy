function printNumbers() {
    var n = parseInt(document.getElementById('tb-first').value);

    for (var i = 1; i <= n; i++) {
        if (i % 35 != 0 ) {
            console.log(i);
        }
    }
}