window.addEventListener("load", solve);

function solve() {
    let numberOfTicketsElement=document.getElementById('num-tickets')
    let seatingElement=document.getElementById('seating-preference')
    let fullNameElement=document.getElementById('full-name')
    let emailElement=document.getElementById('email')
    let phoneElement=document.getElementById('phone-number')
    let purchaseButtonElement=document.getElementById('purchase-btn')

    let previewElement = document.getElementById('ticket-preview');
    let purchasedElement = document.getElementById('ticket-purchase');

    let bottomElement=document.querySelector('.bottom-content')

    purchaseButtonElement.addEventListener('click', onNext);
    function onNext(e){
        e.preventDefault();
        if (numberOfTicketsElement.value == '' ||
            seatingElement.value == '' ||
            fullNameElement.value == '' ||
            emailElement.value == '' ||
            phoneElement.value == ''
          ) {
            return;
          }
    
          let liElementPreview=document.createElement('li')
          liElementPreview.setAttribute('class', 'ticket-purchase');
      
          let articlePreviewElement = document.createElement('article');
      
          let countParagraph = document.createElement('p');
          countParagraph.textContent = `Count: ${numberOfTicketsElement.value}`;
      
          let preferanceParagraph = document.createElement('p');
          preferanceParagraph.textContent = `Preferance: ${seatingElement.value}`;
      
          let fullNameParahraph = document.createElement('p');
          fullNameParahraph.textContent = `To: ${fullNameElement.value}`;
      
          let emailParagraph = document.createElement('p');
          emailParagraph.textContent = `Email: ${emailElement.value}`;
      
          let phoneParagraph = document.createElement('p');
          phoneParagraph.textContent = `Phone number: ${phoneElement.value}`;
          
          let buttonsContainerElement = document.createElement('div');
          buttonsContainerElement.setAttribute('class','btn-container');

          let editbtn = document.createElement('button');
          editbtn.setAttribute('class', 'edit-btn');
          editbtn.textContent = "Edit";

          let nextBtn = document.createElement('button');
          nextBtn.setAttribute('class', 'edit-btn');
          nextBtn.textContent = "Next";

          articlePreviewElement.appendChild(countParagraph);
          articlePreviewElement.appendChild(preferanceParagraph);
          articlePreviewElement.appendChild(fullNameParahraph);
          articlePreviewElement.appendChild(emailParagraph);
          articlePreviewElement.appendChild(phoneParagraph);
          
          buttonsContainerElement.appendChild(editbtn);
          buttonsContainerElement.appendChild(nextBtn);

          liElementPreview.appendChild(articlePreviewElement)
          liElementPreview.appendChild(buttonsContainerElement)

          previewElement.appendChild(liElementPreview)

          let editCount = numberOfTicketsElement.value;
          let editPreferance = seatingElement.value;
          let editName = fullNameElement.value;
          let EditEmail = emailElement.value;
          let EditPhone = phoneElement.value;

          numberOfTicketsElement.value = '';
          seatingElement.value = '';
          fullNameElement.value = '';
          emailElement.value = '';
          phoneElement.value = '';
          purchaseButtonElement.disabled = true;

          editbtn.addEventListener('click', onEdit);
          function onEdit() {
            numberOfTicketsElement.value = editCount;
            seatingElement.value = editPreferance;
            fullNameElement.value = editName;
            emailElement.value = EditEmail;
            phoneElement.value = EditPhone;
      
            liElementPreview.remove();
            purchaseButtonElement.disabled = false;
          }
          nextBtn.addEventListener('click', onContinue);

          function onContinue(){
            let liElementContinue = document.createElement('li');
            liElementContinue.setAttribute('class', 'ticket-purchase');
      
            let articleElementContinue = document.createElement('article');
            articleElementContinue = articlePreviewElement;

            let buttonsContainerElement = document.createElement('div');
            buttonsContainerElement.setAttribute('class','btn-container');

            let buyButton = document.createElement('button');
            buyButton.setAttribute('class', 'buy-btn');
            buyButton.textContent = "Buy";

            buttonsContainerElement.appendChild(buyButton)
            liElementContinue.appendChild(articleElementContinue)
            liElementContinue.appendChild(buttonsContainerElement)

            purchasedElement.appendChild(liElementContinue)
            liElementPreview.remove()

            buyButton.addEventListener('click', onBuy);
            function onBuy(){
                liElementContinue.remove()
                let thankYouElement = document.createElement('h2');
                thankYouElement.textContent = "Thank you for your purchase!";

                let backButton=document.createElement('button')
                backButton.setAttribute('class','back-btn')
                backButton.textContent='Back'
       
                bottomElement.appendChild(thankYouElement)
                bottomElement.appendChild(backButton)

                backButton.addEventListener('click',onBack)
                function onBack(){
                    window.location.reload()
                }
            }
          }
    }
}