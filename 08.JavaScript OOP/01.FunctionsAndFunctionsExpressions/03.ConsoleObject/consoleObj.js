var specialConsole = (function () {
    function writeLine(message, placeHolders) {
        if (placeHolders) {
            message = replacePlaceHolders(message, arguments);
        }

        console.log(message);
    }

    function writeError(errorMessage, placeHolders) {
        if (placeHolders) {
            errorMessage = replacePlaceHolders(errorMessage, arguments);
        }

        console.error(errorMessage);
    }

    function writeWarning(warningMessage, placeHolders) {
        if (placeHolders) {
            warningMessage = replacePlaceHolders(warningMessage, arguments);
        }

        console.warn(warningMessage);
    }

    function replacePlaceHolders(message, arguments) {

        for (var i = 0; i < arguments.length; i++) {
            var placeholdersNumber = '{' + i + '}';

            while (message.indexOf(placeholdersNumber) != -1) {
                message = message.replace(placeholdersNumber, arguments[i + 1]);
            }
        }

        return message;
    }

    return {
        writeLine: writeLine,
        writeError: writeError,
        writeWarning: writeWarning
    };
}());