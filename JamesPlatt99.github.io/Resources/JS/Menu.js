var curPage;
function loadPage(pageToLoad) {
    if(pageToLoad != curPage){
        $("#Content").load("Pages/" + pageToLoad + ".html");   
    }
    curPage = pageToLoad;
}
