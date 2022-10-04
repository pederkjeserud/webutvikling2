<template>

    <header>
        <h1>Artist Admin</h1>
    </header>

    <section class="admin-create">
        <artistAdmin-create></artistAdmin-create>
    </section>

    <section class="admin-update">
        <artistAdmin-update></artistAdmin-update>
    </section>

    <section class="admin-delete">
        <artistAdmin-delete></artistAdmin-delete>
    </section>
    
</template>

<script>
import ArtistAdminCreate from '../components/artistAdmin/ArtistAdminCreate'
import ArtistAdminUpdate from '../components/artistAdmin/ArtistAdminUpdate'
import ArtistAdminDelete from '../components/artistAdmin/ArtistAdminDelete'

export default {
    components: { 
        ArtistAdminCreate, 
        ArtistAdminUpdate,
        ArtistAdminDelete
    }
}
</script>