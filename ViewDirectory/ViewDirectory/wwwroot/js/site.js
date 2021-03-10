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

function showFaculties() {
    let selFaculty = document.querySelector("#facultiesId");
    if (selFaculty != undefined) {
        ajaxQuery("GET", "/Directory/GetGroups", undefined, { "facultyId": +selFaculty.value }, "#result-1");
        selFaculty.onchange = function () {
            ajaxQuery("GET", "/Directory/GetGroups", undefined, { "facultyId": +selFaculty.value }, "#result-1");
        };
    }
}

showFaculties();

function showBids() {
    let setTeacher = document.querySelector("#teachersId");

    if (setTeacher != undefined) {
        ajaxQuery("GET", "/IndividualPlanTerm/GetBids", undefined, { "index": 0 }, "#result-2");
        setTeacher.onchange = function () {
            ajaxQuery("GET", "/IndividualPlanTerm/GetBids", undefined, { "index": setTeacher.selectedIndex }, "#result-2");
        };
    }
}

showBids();