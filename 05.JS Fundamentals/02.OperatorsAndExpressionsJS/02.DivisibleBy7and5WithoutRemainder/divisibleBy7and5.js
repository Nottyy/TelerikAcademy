function onFindBiggerButtonClick() {
    var number = parseInt(document.getElementById("tb-first").value);
    
    if (number % 5 === 0 && number % 7 === 0) {
        console.log(number + " is divisible by 7 and 5!");
    }
    else {
        console.log(number + ' is not divisible by 7 and 5 at the same time!')
    }
}