function init(id){
    document.getElementById(id).addEventListener("mousedown",async () => {

        console.log(id);
        await DotNet.invokeMethodAsync('WPFBlazorChat', 'StartMove')

        document.addEventListener('mousemove', start)

        document.addEventListener('mouseup', stop)

        async function start() {
            await DotNet.invokeMethodAsync('WPFBlazorChat', 'UpdateWindowPos')
        }

        async function stop() {
            await DotNet.invokeMethodAsync('WPFBlazorChat', 'StopMove')
            document.removeEventListener('mousemove', start)
            document.removeEventListener('mouseup', stop)
        }
    })
}

export {
    init
}