const API_KEY = "apiKey=mhiSz2BPtTgsa6PzZk9GUycweyxYWWN5"
const URL = "https://api.giphy.com/v1"
const TRENDING_END_POINT = "/gifs/trending?"
var curIndex = 0;
var mainRequest = new XMLHttpRequest();

$(document).ready(function(){  
    var requestUrl = URL + TRENDING_END_POINT + API_KEY;
    mainRequest.open('GET', requestUrl);
    mainRequest.responseType = 'json';
    mainRequest.send();

    mainRequest.onload = function() {
        populateTrendingGifs();
    }
})

function populateTrendingGifs(){
    var response = mainRequest.response;           
    for(var curResponse in response.data){
        var curImage = document.createElement("img");
        var imageUrl  = response.data[curResponse].images.original.url;
        curImage.setAttribute("src", imageUrl);
        $("#giphyResults").after(curImage);
    };
}