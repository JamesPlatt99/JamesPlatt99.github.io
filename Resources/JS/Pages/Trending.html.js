const API_KEY = "apiKey=mhiSz2BPtTgsa6PzZk9GUycweyxYWWN5"
const URL = "https://api.giphy.com/v1"
const TRENDING_END_POINT = "/gifs/trending?"
const SEARCH_END_POINT = "/gifs/search?"
var curCount = 1;
var mainRequest = new XMLHttpRequest();
var curSearchTerm = URL + TRENDING_END_POINT + API_KEY;
var searchTermWithOffset;

$(document).ready(function(){  
    addMore();
})

var waypoint = new Waypoint({
    element: document.getElementById('More'),
    handler: function() {
      addMore();
    },
    offset: (Waypoint.viewportHeight())
})

function searchGifs(){
    clearGifs();
    curCount = 1;
    var searchTerm = "&q=" + document.getElementById('search').value;
    curSearchTerm = URL + SEARCH_END_POINT + API_KEY + searchTerm;
    addMore();
}

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
        var curImage = document.createElement("img");
        var imageUrl  = response.data[curResponse].images.original.url;
        curImage.setAttribute("onclick", "return copyLink('" + imageUrl + "')");
        curImage.setAttribute("src", imageUrl);
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
}

function copyLink(url) {
    console.log(url);
    window.clipboardData.setData("Text", url);
    return false
}