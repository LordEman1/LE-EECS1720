window.onload = function () {
    document.getElementById("button").onclick = changeText();
    document.getElementById("button1").onclick = removeOption();
}

function changeText() {
    word = document.getElementById("button");
    word.options[word.selectedIndex].text = "word";
  }

function removeOption() {
    var word = document.getElementById("button1");
    word.remove(word.selectedIndex);
}