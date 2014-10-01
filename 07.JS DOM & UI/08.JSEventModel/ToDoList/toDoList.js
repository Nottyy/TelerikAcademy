var addButton = document.getElementById("btn-add");
var removeButton = document.getElementById("btn-remove");
var hideButton = document.getElementById("btn-hide");
var showButton = document.getElementById("btn-show");

addButton.addEventListener('click', addItem);
removeButton.addEventListener('click', removeItem);
showButton.addEventListener('click', showHiddenItems);
hideButton.addEventListener('click', hideItems);

function addItem() {
    event.preventDefault()
    var container = document.getElementById("container");
    var inputValue = document.getElementById('input-text').value;
    document.getElementById('input-text').value = "";

    if (inputValue == "" || inputValue == null) {
        alert("The input item cannot be null!");
        return;
    };
    var checkbox = document.createElement('input');
    checkbox.name = 'checkbox';
    checkbox.type = 'checkbox';

    var label = document.createElement('label');
    label.style.display = 'block';
    label.appendChild(checkbox);

    var span = document.createElement('span');
    span.innerText = inputValue;
    label.appendChild(span);

    container.appendChild(label);
    event.target.item = '';
}

function removeItem() {
    event.preventDefault();

    var checkedItems = document.querySelectorAll('input[type=checkbox]');
    var checkedItemsLength = checkedItems.length;

    for (var i = 0; i < checkedItemsLength; i++) {
        var currentCheckBox = checkedItems[i];

        if (currentCheckBox.checked) {
            var currentCheckBoxParentNodeAsLabel = currentCheckBox.parentNode;
            currentCheckBoxParentNodeAsLabel.parentNode.removeChild(currentCheckBoxParentNodeAsLabel);
        }
    }
}

function hideItems() {
    event.preventDefault();

    var checkedItems = document.querySelectorAll("input[type=checkbox]");
    var checkedItemsLength = checkedItems.length;

    for (var i = 0; i < checkedItemsLength; i++) {
        if (checkedItems[i].checked) {
            checkedItems[i].parentNode.style.display = "none";
        };
    };
}

function showHiddenItems() {
    event.preventDefault();

    var checkedItems = document.querySelectorAll("input[type=checkbox]");
    var checkedItemsLength = checkedItems.length;

    for (var i = 0; i < checkedItemsLength; i++) {
        if (checkedItems[i].parentNode.style.display == "none") {
            checkedItems[i].parentNode.style.display = "block";
        };
    };
}
