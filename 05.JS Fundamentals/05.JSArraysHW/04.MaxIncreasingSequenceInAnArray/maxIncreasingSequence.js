function arrInitialization() {
    var arr = [5, 6, 7, 8, 9, 10, 11, 12, 1, 1, 1, 2, 3, 5, 6, 7, 7, 7, 7, 7, 1, 2, 3, 4, 5, 6, 7];
    var isIncreased;
    var i;
    var maxSequence = 1;
    var currSequence = 1;
    var maxSequenceCount = [];

    for (i = 1; i < arr.length; i++) {
        isIncreased = arr[i] === arr[i - 1] + 1;

        if (isIncreased) {
            currSequence += 1;

            if (currSequence > maxSequence) {
                maxSequence = currSequence;
                maxSequenceCount.length = 0;
                maxSequenceCount.push(arr[i]);
            }
        }
        else {
            currSequence = 1;
        }
    }

    var result = printResult(arr, maxSequence, maxSequenceCount[0]);

    console.log(result);
}

function printResult(arr, maxSequence, maxSequenceElement) {
    var printResult = 'The array: ' + arr + ' has max increasing sequence of ' + maxSequence + ' elements - ';
    var equalElements = "";
    var i = (maxSequenceElement - maxSequence) + 1;
    for (i; i <= maxSequenceElement; i++) {
        equalElements += i + ' ';
    }

    var finalResult = printResult + '{ ' + equalElements + '}';

    return finalResult;
}