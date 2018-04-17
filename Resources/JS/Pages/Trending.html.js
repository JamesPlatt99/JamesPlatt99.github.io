const API_KEY = "apiKey=mhiSz2BPtTgsa6PzZk9GUycweyxYWWN5"
const URL = "https://api.giphy.com/v1"
const TRENDING_END_POINT = "/gifs/trending?"
const SEARCH_END_POINT = "/gifs/search?"
var curCount = 1;
var mainRequest = new XMLHttpRequest();
var curSearchTerm = URL + TRENDING_END_POINT + API_KEY;
var searchTermWithOffset;

$(document).ready(function(){  
    $("#CopyArea").hide();    
    addMore();
})

$('#search').submit(function () {
    clearGifs();
    curCount = 1;
    var searchTerm = "&q=" + document.getElementById('search').value;
    curSearchTerm = URL + SEARCH_END_POINT + API_KEY + searchTerm;
    addMore();
    return false;
});

var waypoint = new Waypoint({
    element: document.getElementById('More'),
    handler: function() {
      addMore();
    },
    offset: (Waypoint.viewportHeight())
})

function addMore(){
    loading = true;
    searchTermWithOffset = curSearchTerm + "&offset=" + curCount;
    generateRequest();
}

function generateRequest(){
    mainRequest.open('GET', searchTermWithOffset + "&limit=10");
    mainRequest.responseType = 'json';
    mainRequest.send();

    mainRequest.onload = function() {
        populateGifs();
    }
}

function populateGifs(){
    var response = mainRequest.response;           
    for(var curResponse in response.data){
        var imageUrl  = response.data[curResponse].images.original.url;
        var curImage = document.createElement("img");
        curImage.setAttribute("src", imageUrl);
        curImage.setAttribute("alt", "Some GIF");
        curImage.setAttribute("onclick", "copyText('" + imageUrl + "')");
        curImage.setAttribute("class", "gif");
        $("#More").before(curImage);
        curCount++;
    };
    Waypoint.refreshAll()
}

function clearGifs(){
    var element = document.getElementsByClassName("gif");
    var index;
    for (index = element.length - 1; index >= 0; index--) {
        element[index].parentNode.removeChild(element[index]);
    }
    Waypoint.refreshAll();
}

function copyText(url){
    $("#CopyArea").show();        
    $("#copyText").show(); 
    var copyText = document.getElementById("copyText");
    copyText.visibility = "visible";
    copyText.value = url;
    copyText.select();
    document.execCommand("Copy");
    $("#copyText").hide();     
    setTimeout(function(){closeCopyArea()}, 2500);
}

function closeCopyArea(){
    $("#CopyArea").fadeOut(2500);
    return false;
}