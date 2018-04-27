$(document).ready(function(){      
    $("#Header").load("Resources/Elements/Header.html"); 
    $("#Menu").load("Resources/Elements/Menu.html"); 
    $("#Home").load("Pages/Home.html"); 
    $("#About").load("Pages/About.html"); 
    $("#Trending").load("Pages/Trending.html"); 
    $("#GreatWebsites").load("Pages/GreatWebsites.html"); 
    var page = getUrlParameter('page')
    if(page === null){
        page = "Home";
    }
    loadPage(page);
    var content = document.getElementById('Menu');
    content.addEventListener('swiperight', function (event) {
        console.log("test");
        loadNextPage(-1);
    });
    content.addEventListener('swipeleft', function (event) {
        console.log("test");
        loadNextPage(1);
    }); 
});

function getUrlParameter(param) {
    var parameters = decodeURIComponent(window.location.search.substring(1)).split('&');
    var curParameter;

    for (var i = 0; i < parameters.length; i++) {
        curParameter = parameters[i].split('=');
        if (curParameter[0] == param && curParameter.length > 1) {
            return curParameter[1];
        }
    }
    return null;
};

function loadNextPage(dir){
    console.log(test);
    var page = getUrlParameter('page')
    var index = pages.indexOf(page);
    loadPage(pages[(index + dir) % pages.length]);    
    return false;
} 