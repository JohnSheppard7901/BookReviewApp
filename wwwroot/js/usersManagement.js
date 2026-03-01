function toggleEdit(userId) {
    const viewRow = document.getElementById(`row-view-${userId}`);
    const editRow = document.getElementById(`row-edit-${userId}`);

    // wenn die editRow sichtbar ist (display !== 'none'), ist isEditing true
    const isEditing = editRow.style.display !== 'none';

    if (isEditing) {
        // Inputs zurücksetzen auf ihre ursprünglichen Werte
        editRow.querySelectorAll('input').forEach(input => {
            input.value = input.defaultValue;
        });
    }

    viewRow.style.display = isEditing ? '' : 'none';
    editRow.style.display = isEditing ? 'none' : '';

    console.log("JS ist richtig angebunden!")
}