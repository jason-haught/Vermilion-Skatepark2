function $id(id) {
    return document.getElementById(id);
}

// asyncrhonously fetch the html template partial from the file directory,
// then set its contents to the html of the parent element
function loadHTML(url, id) {
    req = new XMLHttpRequest();
    req.open('GET', url);
    req.send();
    req.onload = () => {
        $id(id).innerHTML = req.responseText;
    };
}

// use #! to hash
router = new Navigo(null, true, '#!');
router.on({
    // 'view' is the id of the div element inside which we render the HTML
    'home': () => { loadHTML('./templates/home.html', 'view'); },
    'about': () => { loadHTML('./templates/about.html', 'view'); },
    'blog': () => { loadHTML('./templates/blog.html', 'view'); }
});

// set the default route
//router.on(() => { $id('view').innerHTML = '<h2>Home Page Default route</h2>'; });
router.on(() => { loadHTML('./templates/home.html', 'view'); });

// set the 404 route
router.notFound((query) => { $id('view').innerHTML = '<h3>Couldn\'t find the page you\'re looking for...</h3>'; });

router.resolve();
