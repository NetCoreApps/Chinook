/**: Extend locode App with custom JS **/

/** Custom [Format] method to style text with custom class
 * @param {*} val
 * @param {{cls:string}} [options] */
function stylize(val, options) {
    let cls = options && options.cls || 'text-green-600'
    return `<span class="${cls}">${val}</span>`
}
