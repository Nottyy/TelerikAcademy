var domModule = (function () {
    var buffer = [];

    function addElement(parentSelector, element) {
        var parent = document.querySelector(parentSelector);

        if (parent) {
            parent.appendChild(element);
        }
    }

    function removeElement(parentSelector, childSelector) {
        var parent = document.querySelector(parentSelector);

        if (parent) {
            var childElement = document.querySelector(childSelector);

            if (childElement) {
                parent.removeChild(childElement);
            }
        }
    }

    function addHandler(elementSelector, eventType, eventHandler) {
        var elements = document.querySelectorAll(elementSelector);

        if (elements) {
            var elementsCount = elements.length;

            for (var i = 0; i < elementsCount; i++) {
                elements[i].addEventListener(eventType, eventHandler);
            }
        }
    }

    function appendToBuffer(parentSelector, element) {
        if (buffer[parentSelector]) {
            buffer[parentSelector].push(element);

            var currentElementsCount = buffer[parentSelector].length;

            if (currentElementsCount == 100) {
                var docFrag = document.createDocumentFragment();

                for (var i = 0; i < 100; i++) {
                    docFrag.appendChild(buffer[parentSelector][i]);
                }

                var parent = document.querySelector(parentSelector);
                parent.appendChild(docFrag);

                buffer[parentSelector] = [];
            }
        }
        else {
            buffer[parentSelector] = [];
            buffer[parentSelector].push(element);
        }
    }

    return {
        appendChild: addElement,
        removeChild: removeElement,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer
    }

}());