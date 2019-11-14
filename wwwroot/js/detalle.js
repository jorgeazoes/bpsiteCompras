(function () {
    var button = document.querySelector("#btnDetalleCot");
    button.addEventListener("click", function (event) {

        let divllamar = document.getElementById("llamarAsync");
        console.log(divllamar);
        divllamar += document.innerHtml = `@{ @await Component.InvokeAsync("Cotizaciond",new {param1 = "359", param2 = "1"})}`;
        console.log(divllamar);  
    }, false);
})();



//let tablad = document.querySelector("#tabledetalle");
//let botond = document.querySelector("#btnDetalleCot");
// console.log(tablad);  

   
