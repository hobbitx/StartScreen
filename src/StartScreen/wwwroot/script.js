
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
    document.body.style.setProperty('--main-color', color);
    let rgb = hexToRgb(color);
    let str =  rgb.r + "," + rgb.g + ","+ rgb.b;
    document.body.style.setProperty('--rgb-color',str );

});



function colorSelect(t) {
    document.body.style.setProperty('--main-color', t.value);
        document.getElementById("main").value = t.value;

    let rgb = hexToRgb(t.value);
    let str = rgb.r + "," + rgb.g + "," + rgb.b;
    document.body.style.setProperty('--rgb-color', str);
}
