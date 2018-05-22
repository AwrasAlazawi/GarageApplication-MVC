function myFunction() {
    var color = document.getElementById("colorId").value;
;

    // Ensure that the value is string
    if (!isNaN(color))
        alert("Please enter a color as a text not as a number");  
}