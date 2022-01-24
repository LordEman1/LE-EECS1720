window.onload = function () {
    document.getElementById("button").onclick = changeText();
    document.getElementById("button1").onclick = removeOption();
}

function changeText() {
    x = document.getElementById("mySelect");
    x.options[x.selectedIndex].text = document.getElementById("inputText");
  }

function removeOption() {
    var x = document.getElementById("mySelect");
    x.remove(x.selectedIndex);
}