function merge(cp:number[],arr:number[], low:number, mid:number, high:number) {
  let i = low, j = mid + 1

  for (let k = low; k <= high; k++) {
    cp[k] = arr[k]
  }

  for (let k = low; k <= high; k++) {
    if (i > mid) {
      arr[k] = cp[j++]
    } else if (j > high) {
      arr[k] = cp[i++]
    }
    else if (cp[i] < cp[j]) {
      arr[k] = cp[i++]
    } else {
      arr[k] = cp[j++]
    }
  }
}

// bottom up merge sort
function sort(nums:number[]) {
  const cp = [...nums]
  const n = nums.length

  for (let len = 1; len < n; len *= 2) {
    for (let low = 0; low < n - len; low += 2 * len) {
      const md = low + len - 1
      const h = Math.min(md + len, n - 1)
      merge(cp,nums, low, md, h)
    }
  }
  return nums
}


