
function hexToRgb(hex) {
    var result = /^#?([a-f\d]{2})([a-f\d]{2})([a-f\d]{2})$/i.exec(hex);
    return result ? {
        r: parseInt(result[1], 16),
        g: parseInt(result[2], 16),
        b: parseInt(result[3], 16)
    } : null;
}

document.addEventListener("DOMContentLoaded", function (event) {
    let color = document.getElementById("main").value;
    
    document.body.style.setProperty('--main-color', '#E53153');
    let rgb = hexToRgb(color);
    if (rgb != null) {
        let str = rgb.r + "," + rgb.g + "," + rgb.b;
        document.body.style.setProperty('--rgb-color', str);
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
function helpPhrase(t) {
    console.log(t.value);
}

function title(t) {
    console.log(t.value);
}

function addMenu() {
        var txt;
        var person = prompt("Please enter menu name:", "");
        if (person == null || person == "") {
            txt = "User cancelled the prompt.";
        } else {

            var myInit = {
                method: 'post',
                body: person
            };
            fetch("/menu?title="+person, myInit)
        }
    
}
function addSearch() {

}


function colorSelect(t) {
    document.body.style.setProperty('--main-color', t.style.backgroundColor);
    document.getElementById("main").value = t.style.backgroundColor;

    let rgb = hexToRgb(t.value);
    let str = rgb.r + "," + rgb.g + "," + rgb.b;
    document.body.style.setProperty('--rgb-color', str);
}
