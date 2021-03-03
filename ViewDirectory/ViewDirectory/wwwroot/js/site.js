document.addEventListener("mouseover", (event) => {
    let dataContentAttribute = event.target.getAttribute("data-content");
    let dataValueAttribute = event.target.getAttribute("data-value");;

    switch (dataContentAttribute) {
        case "group":
            targetClear();
            event.target.classList.add("target");
            ajaxQuery("GET", "/Directory/ShowLoads", undefined, { "groupId": +dataValueAttribute }, "#result");
            break;
        default:
            break;
    }
});

function ajaxQuery(ajaxType, ajaxUrl, loadElement, dataDictionary, resultId) {
    $.ajax({
        type: ajaxType,
        url: ajaxUrl,
        beforeSend: () => {
            $(loadElement).show();
        },
        complete: () => {
            $(loadElement).hide();
        },
        onBegin: "ajaxBegin",
        data: dataDictionary,
        success: (data) => {
            $(resultId).html(data);
        }
    });
}

function targetClear() {
    let allGroups = document.querySelectorAll(".group");
    console.log(allGroups.length);
    for (var i = 0; i < allGroups.length; i++) {
        allGroups[i].classList.remove("target");
    }
}