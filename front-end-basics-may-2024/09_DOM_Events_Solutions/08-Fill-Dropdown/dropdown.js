function addItem() {
    let textItem = document.getElementById("newItemText");
    let valueItem = document.getElementById("newItemValue");
    let selectItem = document.getElementById("menu");

    let option = document.createElement('option');

    option.textContent = textItem.value;
    option.value = valueItem.value;
    selectItem.appendChild(option);

    textItem.value = '';
    valueItem.value = '';
}