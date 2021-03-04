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

document.addEventListener("click", (event) => {
    let dataContentAttribute = event.target.getAttribute("data-content");
    let dataValueAttribute = event.target.getAttribute("data-value");
    let dataBidsAttribute = event.target.getAttribute("data-bids");

    switch (dataContentAttribute) {
        case "bid-information":
            let bidInformationItem = document.querySelectorAll(`.bid-information-${+dataBidsAttribute}`)[+dataValueAttribute];

            if (bidInformationItem.getAttribute("hidden") != undefined)
                bidInformationItem.removeAttribute("hidden");
            else
                bidInformationItem.setAttribute("hidden", true);
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
    for (var i = 0; i < allGroups.length; i++) {
        allGroups[i].classList.remove("target");
    }
}