function findWord() {
    var text = "We are living in an yellow submarine. In the sky there are no clouds. So we are drinking all the day. We will move out of it in 5 days.";
    var wordToSearch = " in "
    var isCaseSensitive = false;
    
    CountOccurrenceWord(text, wordToSearch);
    CountOccurrenceWord(text, wordToSearch, true);

    function CountOccurrenceWord(text, wordToSearch, isCaseSensitive) {
        isCaseSensitive = isCaseSensitive || false;
        var counter = 0;

        if (isCaseSensitive) {
            var strArr = text.split(wordToSearch);
            for (var word in strArr) {
                counter += 1;
            }

            console.log("The count of word '" + wordToSearch + "' (case-insensitive search)  is: " + counter);
        }
        else {
            var index = text.indexOf(wordToSearch);

            while (index >= 0) {
                counter += 1;
                index = text.indexOf(wordToSearch, index + 1);
            }

            console.log("The count of word '" + wordToSearch + "' (case-sensitive search)  is: " + counter);
        }
    }
}