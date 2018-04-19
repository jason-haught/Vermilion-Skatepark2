function $id(id) {
    return document.getElementById(id);
}

// asyncrhonously fetch the html template partial from the file directory,
// then set its contents to the html of the parent element
//function loadHTML(url, id) {
//    req = new XMLHttpRequest();
//    req.open('GET', url);
//    req.send();
//    req.onload = ()=> {
//        //$id(id).innerHTML = req.responseText;
//        $("#" + id).html(req.responseText); //allow scripts
//    };
//}

function loadHtmlAsync(url, id, isCache)
{
    var isCacheCall = false;
    if (isCache) { isCacheCall = isCache; }

    $.ajax({
        method: "GET",
        cache: isCacheCall,
        url: url,
        success: function (result) {
            $("#" + id).html(result);
        }
    });
}

// use #! to hash
router = new Navigo(null, true, '#!');
//router.on({
//    // 'view' is the id of the div element inside which we render the HTML
//    'home': () => { loadHtmlAsync('./templates/home.html', 'view'); },
//    'about': () => { loadHtmlAsync('./templates/about.html', 'view'); },
//    'facebook': () => { loadHtmlAsync('./templates/facebook.html', 'view'); },
//    'blog': () => { loadHtmlAsync('./templates/blog.html', 'view'); }
//});

router.on({
    // 'view' is the id of the div element inside which we render the HTML
    'home': function() { loadHtmlAsync('./templates/home.html', 'view', false); },
    'about': function () { loadHtmlAsync('./templates/about.html', 'view', true); },
    'facebook': function () { loadHtmlAsync('./templates/facebook.html', 'view', false); },
    'blog': function () { loadHtmlAsync('./templates/blog.html', 'view', false); }
});

// set the default route
//router.on(() => { $id('view').innerHTML = '<h2>Home Page Default route</h2>'; });
//router.on(() => { loadHtmlAsync('./templates/home.html', 'view'); });

router.on(function() { loadHtmlAsync('./templates/home.html', 'view'); });

// set the 404 route
//router.notFound((query) => { $id('view').innerHTML = '<h3>Couldn\'t find the page you\'re looking for...</h3>'; });
router.notFound(function (query){ $id('view').innerHTML = '<h3>Couldn\'t find the page you\'re looking for...</h3>'; });

router.resolve();
