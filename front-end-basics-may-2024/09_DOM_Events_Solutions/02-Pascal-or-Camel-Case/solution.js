function solve() {
  let textInput = document.getElementById("text").value.toLowerCase();
  let namingConvention = document.getElementById("naming-convention").value;
  let resultField = document.getElementById("result");

  let splittedText = textInput.split(' ');
  let resultString = '';

  //this is an example
  if (namingConvention == "Camel Case") {
    resultString += splittedText[0];
    for (let i = 1; i < splittedText.length; i++) {
      resultString += splittedText[i][0].toUpperCase() + splittedText[i].slice(1, splittedText[i].length);
    }
    resultField.textContent = resultString;
  }
  else if(namingConvention == "Pascal Case"){
    resultString += splittedText[0][0].toUpperCase() + splittedText[0].slice(1, splittedText[0].length);
    for (let i = 1; i < splittedText.length; i++) {
      resultString += splittedText[i][0].toUpperCase() + splittedText[i].slice(1, splittedText[i].length);
    }
    resultField.textContent = resultString;
  }
  else{
    resultField.textContent = "Error!"
  }
}