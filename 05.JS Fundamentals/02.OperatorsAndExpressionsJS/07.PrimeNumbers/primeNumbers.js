function onFindBiggerButtonClick() {
    var number = parseInt(document.getElementById('tb-first').value);
    var isPrime = true;

    if (number < 2) {
        console.log('Numbers smaller than 2 are not prime numbers!')
        isPrime = false;
    }
    else {
        for (var i = 2, l = Math.floor(number / 2) ; i < l; i++) {
            if (number % i == 0) {
                isPrime = false;
            }
        }
    }

    if (isPrime) {
        console.log('The number: ' + number + ' is prime!');
    }
    else {
        console.log('The number: ' + number + ' is NOT prime!');
    }

}