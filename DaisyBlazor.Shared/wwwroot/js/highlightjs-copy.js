function copyCode(button, text) {
    if (navigator.clipboard) {
        navigator.clipboard.writeText(text).then(function () {
            button.dataset.copied = true;
            setTimeout(() => {
                button.dataset.copied = false;
            }, 2e3)
        })
    }
} 