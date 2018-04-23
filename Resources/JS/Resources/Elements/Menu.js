var pages = ["Home", "About", "GreatWebsites", "Trending"];

function loadPage(pageToLoad) {
   for(var i = 0; i < pages.length; i++){
       $("#" + pages[i]).hide();            
   }   
   $("#" + pageToLoad).show();    
   history.pushState({}, null, "?page=" + pageToLoad);
   return false;
} 