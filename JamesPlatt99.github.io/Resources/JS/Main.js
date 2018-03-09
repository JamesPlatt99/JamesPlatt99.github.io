$(document).ready(function(){      
    $("#Header").load("Resources/Elements/Header.html"); 
    $("#Menu").load("Resources/Elements/Menu.html"); 

    var page = getUrlParameter('page')
    if(page === null){
        page = "Home";
    }
    loadPage(page);
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