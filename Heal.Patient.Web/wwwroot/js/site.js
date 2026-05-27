(function () {
	const STORAGE_KEY = "portal-font-scale";
	const STEP = 0.1;
	const MIN = 0.9;
	const MAX = 1.4;

	const increase = document.getElementById("font-increase");
	const decrease = document.getElementById("font-decrease");

	function normalize(value) {
		return Math.min(MAX, Math.max(MIN, Number(value.toFixed(2))));
	}

	function getCurrentScale() {
		const fromStorage = parseFloat(localStorage.getItem(STORAGE_KEY) || "1");
		if (Number.isNaN(fromStorage)) {
			return 1;
		}

		return normalize(fromStorage);
	}

	function applyScale(scale) {
		const normalized = normalize(scale);
		document.documentElement.style.setProperty("--portal-font-scale", normalized.toString());
		localStorage.setItem(STORAGE_KEY, normalized.toString());
	}

	applyScale(getCurrentScale());

	if (increase) {
		increase.addEventListener("click", function () {
			applyScale(getCurrentScale() + STEP);
		});
	}

	if (decrease) {
		decrease.addEventListener("click", function () {
			applyScale(getCurrentScale() - STEP);
		});
	}
})();
