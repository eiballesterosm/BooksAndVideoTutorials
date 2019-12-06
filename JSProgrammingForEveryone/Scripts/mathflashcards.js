function GenerateNumbers() {
    var numOne = Math.floor(Math.random() * 10) + 1;
    var numTwo = Math.floor(Math.random() * 10) + 1;
    var correctAnswer = numOne + numTwo;
}

function Addition() {
    var ourAnswer = document.getElementById("answer").value;
    if (!isNaN(ourAnswer)) {
        //document.getElementById("output").innerHTML = ourAnswer;
        if (ourAnswer == correctAnswer) {
            document.getElementById("output").innerHTML = "Correct!!! " + numOne + " + " + numTwo + " = " + correctAnswer;
        }
        else {
            document.getElementById("output").innerHTML = "Incorrect";
        }
    }
    else {
        document.getElementById("output").innerHTML = "Our answer is not a number!!!!";
    }
}

function NewCard() {
    document.getElementById("output").innerHTML = "";
    document.getElementById("answer").value = "";
    numOne = Math.floor(Math.random() * 10) + 1;
    numTwo = Math.floor(Math.random() * 10) + 1;
    correctAnswer = numOne + numTwo;
    document.getElementById("title").innerHTML = numOne + " + " + numTwo;
}