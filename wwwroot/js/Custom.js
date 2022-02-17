let index = 0;

function AddTag() {
    //Get a referece to the TagEntry input element
    var tagEntry = document.getElementById("TagEntry");


    //Lets use the new search function to help detect an error state
    let searchResult = searchDefects(tagEntry.value);
    if (searchResult != null) {
        //Trigger my sweet alert for whatever condition is contained in the searchResult var

        swalWithDarkButton.fire({
            html: `<span>${searchResult}</span>`,
        });
    }
    else {
        let newOption = new Option(tagEntry.value, TagEntry.value);
        document.getElementById("TagList").options[index++] = newOption;
    }

    // Clear out the TagEntry control 
    tagEntry.value = "";
    return true;
}

function DeleteTag() {
    let tagCount = 1;

    let tagList = document.getElementById("TagList");

    if (!tagList) return false;

    if (tagList.selectedIndex == -1) {
        swalWithDarkButton.fire({
            html: "<span class='font-weight-bolder'>Choose a Tag before deleting</span>"
        });

        return true;

    }

    while (tagCount > 0) {
        if (tagList.selectedIndex >= 0) {
            tagList.options[tagList.selectedIndex] = null;
            --tagCount;
        }
        else
            tagCount = 0;
        index--;
    }
}

$("form").on("submit", function () {
    $("#TagList option").prop("selected", "selected");
})

if (tagValues != '') {
    let tagArray = tagValues.split(",");
    for (let loop = 0; loop < tagArray.length; loop++) {
        ReplaceTag(tagArray[loop], loop);
        index++;
    }
}

function ReplaceTag(tag, index) {
    let newOption = new Option(tag, tag);
    document.getElementById("TagList").options[index] = newOption;
}


function searchDefects(str) {
    if (str == "") {
        return 'Empty tags are not permitted'
    }

    var tagElemenets = document.getElementById('TagList');
    if (tagElemenets) {
        let options = tagElemenets.options;
        for (let index = 0; index < options.length; index++) {
            if (options[index].value == str)
                return `The Tag #${str} was detected as a duplicate and is not permitted`
        }

    }


}

const swalWithDarkButton = Swal.mixin({
    customClass: {
        confirmButton: 'btn btn-danger btn-sm btn-block btn-outline-dark'
    },
    imageUrl: '/img/oopsimage.png',
    /*timer: 6000,*/
    imageWidth: 90,
    imageHeight: 75,
    buttonsStyling: false
});