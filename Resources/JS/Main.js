$(document).ready(function(){      
    $("#Header").load("Resources/Elements/Header.html"); 
    $("#Menu").load("Resources/Elements/Menu.html"); 
    $("#Home").load("Pages/Home.html"); 
    $("#About").load("Pages/About.html"); 
    $("#GreatWebsites").load("Pages/GreatWebsites.html"); 
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

function switchCSS(){
    var inputs = document.getElementsByTagName('link');
    for(var i = 0; i < inputs.length; i++) {
        swapStyleSheet(inputs(i));
    }
}
function swapStyleSheet(sheet){
    if(sheet.Attribute("href").split('/')(3) === "alt"){
        sheet.setAttribute("href") = "Resources/Style/" + "Test";
    }
}