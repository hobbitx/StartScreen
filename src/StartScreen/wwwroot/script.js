
function hexToRgb(hex) {
    var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    console.log("passou");
    return result ? {
        r: parseInt(result[1], 16),
        g: parseInt(result[2], 16),
        b: parseInt(result[3], 16)
    } : null;
}


function changeSubmenu(event) {

    console.log(event.id);
}
function changeTitle(event) {

    let x = document.getElementById("greeting-phrase");
    fetch("/Offer?offerquestion=" + event.value)
        .then(function (response) {
            x.innerHTML = event.value;
        });

    sessionStorage.setItem("Title",event.value);
}


function changeTitleMenu(event) {

   
    let k = event.id.substring(0, 4) + "s" + event.id.substring(4);
    console.log(k);
    let x = document.getElementById(k);
    x.innerText = event.value;

    console.log(event.id);
   
}

function changeOffer(event) {

    let x = document.getElementById("offer-question");
    fetch("/Title?title=" + event.value)
        .then(function (response) {
            x.innerHTML = event.value;
        }); 

    sessionStorage.setItem("Offer", event.value);
}

document.addEventListener("DOMContentLoaded", function (event) {
    let color = document.getElementById("main").value;
    document.body.style.setProperty('--main-color', '#000000');
    sessionStorage.setItem("update", "true");
    let rgb = hexToRgb(color);
    if (rgb != null) {
        let str = rgb.r + "," + rgb.g + "," + rgb.b;
        document.body.style.setProperty('--rgb-color', str);
    }
    if (sessionStorage.getItem("Title") != null) {
        let x = document.getElementById("Title");
        x.value = sessionStorage.getItem("Title");
        let y = document.getElementById("greeting-phrase");
        y.innerHTML = sessionStorage.getItem("Title");
    }

    if (sessionStorage.getItem("Offer") != null) {
        let x = document.getElementById("OfferQuestion");
        x.value = sessionStorage.getItem("Offer");
        let y = document.getElementById("offer-question");
        y.innerHTML = sessionStorage.getItem("Title");
    }
    setCollapsible();
});

function setCollapsible() {
    var coll = document.getElementsByClassName("collapsible");
    var i;

    for (i = 0; i < coll.length; i++) {
        coll[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var content = this.nextElementSibling;
            if (content.style.display === "block") {
                content.style.display = "none";
            } else {
                content.style.display = "block";
            }
        });
    }
}