function loadPage(pageToLoad) {
   $("#Home").hide();
   $("#About").hide();
   $("#GreatWebsites").hide();
   
   $("#" + pageToLoad).show();    
   //False return prevents page refresh
   history.pushState({}, null, "?page=" + pageToLoad);
   return false;
} 