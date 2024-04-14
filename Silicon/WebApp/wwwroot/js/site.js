document.addEventListener("DOMContentLoaded", () => {
    let btnMenu = document.querySelector('.btn-menu')
    let nav = document.querySelector('nav')

    btnMenu.addEventListener('click', () => {
        btnMenu.classList.toggle('active')
        btnMenu.classList.toggle('fixed')

        nav.classList.toggle('active')
    })

    window.addEventListener('resize', () => {
        btnMenu.classList.remove('active')
        btnMenu.classList.remove('fixed')

        nav.classList.remove('active')
    })
})

// dark mode
document.addEventListener('DOMContentLoaded', function () {
    let sw = document.querySelector('#theme-switch-mode')

    sw.addEventListener('change', function () {
        let theme = this.checked ? "dark" : "light"

        fetch(`/sitesettings/changetheme?mode=${theme}`)
        .then(res => {
            if (res.ok) {
                window.location.reload()
            }
            else {
                console.log('hello world')
            }
        })
    })
})

document.addEventListener('DOMContentLoaded', function () {

    handleProfileImageUpload()
    select()

})

function handleProfileImageUpload() {
    try {

        let fileUploader = document.querySelector('#fileUploader')
        if (fileUploader != undefined) {
            fileUploader.addEventListener('change', function () {
                if (this.files.length > 0) {
                    this.form.submit()
                }
            })
        }

    }
    catch { }
}

function select() {
    try {
        let select = document.querySelector('.select')
        let selected = select.querySelector('.selected')
        let selectOptions = select.querySelector('.select-options')

        selected.addEventListener('click', function () {
            selectOptions.style.display = (selectOptions.style.display === 'block') ? 'none' : 'block'
        })

        let options = selectOptions.querySelectorAll('.option')
        options.forEach(function (option) {
            option.addEventListener('click', function () {
                selected.innerHTML = this.textContent
                selectOptions.style.display = 'none'
                let category = this.getAttribute('data-value')

                updateCoursesByFilter(category)
            })
        })

    }
    catch { }
}