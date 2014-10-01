function changedTextInAllRegions() {
    var text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";
    console.log('Original text - ' + text);

    var changedText = "";
    changedText = toUpCase(text);
    changedText = toLowCase(changedText);
    changedText = toMixCase(changedText);
    console.log('Changed text - ' + changedText);

    function toUpCase(text) {
        var startIndex = text.indexOf('<upcase>');

        while (startIndex > -1) {
            var upcaseSubStr = text.substring(startIndex + 8, text.indexOf('</upcase>', startIndex + 1));
            var upcaseSubStrToReplace = upcaseSubStr.toUpperCase();
            text = text.replace(upcaseSubStr, upcaseSubStrToReplace);
            text = text.replace('<upcase>', '');
            text = text.replace('</upcase>', '');
            startIndex = text.indexOf('<upcase>', startIndex + 1);
        }

        return text;
    }

    function toLowCase(text) {
        var startIndex = text.indexOf("<lowcase>");

        while (startIndex > -1) {
            var lowcaseSubStr = text.substring(startIndex + 9, text.indexOf("</lowcase>", startIndex + 1));
            var lowcaseSubStrToReplace = lowcaseSubStr.toLowerCase();
            text = text.replace(lowcaseSubStr, lowcaseSubStrToReplace);
            text = text.replace('<lowcase>', '');
            text = text.replace('</lowcase>', '');
            startIndex = text.indexOf("<lowcase>", startIndex + 1);
        }

        return text;
    }

    function toMixCase(text) {
        var startIndex = text.indexOf("<mixcase>");

        while (startIndex > -1) {
            var mixcaseSubStr = text.substring(startIndex + 9, text.indexOf("</mixcase>", startIndex + 1));
            var mixedText = new String(mixcaseSubStr);

            for (var i = 0; i < mixedText.length ; i++) {
                if (i % 2 == 0) {
                    mixedText = mixedText.replace(mixedText[i], mixedText[i].toUpperCase())
                }
                else {
                    mixedText = mixedText.replace(mixedText[i], mixedText[i].toLowerCase())
                }
            }

            text = text.replace(mixcaseSubStr, mixedText);
            text = text.replace('<mixcase>', '');
            text = text.replace('</mixcase>', '');
            startIndex = text.indexOf("<mixcase>", startIndex + 1);
        }

        return text;
    }
}