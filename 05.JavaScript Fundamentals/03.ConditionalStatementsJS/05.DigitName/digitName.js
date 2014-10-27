function onFindBiggerButtonClick() {
    var digit = parseInt(document.getElementById('tb-first').value);
    
    if (isNaN(digit)) {
        console.log('Not a number! Try again!')
    }
    else{
        console.log('The digit name is: ');
        switch (digit) {
            case 1: console.log("one"); break;
            case 2: console.log("two"); break;
            case 3: console.log("three"); break;
            case 4: console.log("four"); break;
            case 5: console.log("five"); break;
            case 6: console.log("six"); break;
            case 7: console.log("seven"); break;
            case 8: console.log("eight"); break;
            case 9: console.log("nine"); break;
            case 10: console.log("ten"); break;
            default: console.log("Display only digits between 1 and 10"); break;
        }
    }
}