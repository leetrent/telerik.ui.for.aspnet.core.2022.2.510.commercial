$(document).on("click", ".try-telerik", function () {
    var themeName = selectedTheme;
    var demoUrl = window.location.href;
    var firstTab = $(".source-code").find("ul.tabstrip-items li").first();
    var sourceUrl = firstTab.data("url");
    var firstPane = $(".source-code").find(".tabstrip-pane").first();
    var content = firstPane.find("pre").text();
    var promise = fetchContent(sourceUrl, content);
    var form = $("#repl-form");

    $("#ThemeName").val(themeName);
    $("#DemoUrl").val(demoUrl);

    promise.then(function (content) {
        $("#DemoContent").val(content);
        if (location.href.indexOf("dev.progress") >= 0) {
            form.attr("action", "https://staging.netcorerepl.telerik.com/");
        }
        form.submit();
    });
});

function fetchContent(url, content) {
    return new Promise(function (resolve, reject) {
        if (!content) {
            $.get(url).success(function (response) {
                resolve(response.replace("<pre class='prettyprint'>", '').replace("</pre>", ''));
            });
        } else {
            resolve(content);
        }
    });
}
