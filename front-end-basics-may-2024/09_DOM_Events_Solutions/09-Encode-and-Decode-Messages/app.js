function encodeAndDecodeMessages() {
    let buttons = document.getElementsByTagName("button");
    let encoodeButton = buttons[0];
    let decodeButton = buttons[1];

    let textAreas = document.getElementsByTagName("textarea");
    let encoodeTextArea = textAreas[0];
    let decodeTextArea = textAreas[1];

    function transformText(text, transformationFunction)
    {
        return text.split('').map(transformationFunction).join('');
    }

    function nextChar(char)
    {
        return String.fromCharCode(char.charCodeAt() + 1);
    }

    function previousChar(char)
    {
        return String.fromCharCode(char.charCodeAt() + -1);
    }

    function encodeText(){
        decodeTextArea.value = transformText(encoodeTextArea.value, nextChar);
        encoodeTextArea.value = "";
    }

    function decodeText(){
        decodeTextArea.value = transformText(decodeTextArea.value, previousChar);
    }

    encoodeButton.addEventListener('click', encodeText)
    decodeButton.addEventListener('click', decodeText)
}